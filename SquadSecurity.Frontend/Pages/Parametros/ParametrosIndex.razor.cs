using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using SquadSecurity.Frontend.Repositories;
using SquadSecurity.Shared.Entities;
using System.Net;

namespace SquadSecurity.Frontend.Pages.Parametros
{
    public partial class ParametrosIndex
    {
        private int currentPage = 1;
        private int totalPages;
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Parameter, SupplyParameterFromForm] public string Page { get; set; } = null!;
        [Parameter, SupplyParameterFromForm] public string Filter { get; set; } = null!;
        public List<Parametro>? Parametros { get; set; }
        protected async override Task OnInitializedAsync()
        {
            await LoadAsync();
        }
        private async Task SelectedPageAsync(int page)
        {
            if (!string.IsNullOrWhiteSpace(Page))
            {
                page = int.Parse(Page);
            }

            currentPage = page;
            await LoadAsync(page);
        }
        private async Task LoadAsync(int page = 1)
        {
            if (!string.IsNullOrWhiteSpace(Page))
            {
                page = int.Parse(Page);
            }

            var ok = await LoadListAsync(page);

            if (ok)
            {
                await LoadPageAsync();
            }
        }
        private async Task<bool> LoadListAsync(int page)
        {
            var url = $"api/parametros?page={page}";
            if (!string.IsNullOrEmpty(Filter))
            {
                url += $"&filter={Filter}";
            }

            var responseHttp = await Repository.GetAsync<List<Parametro>>(url);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return false;
            }
            Parametros = responseHttp.Response;
            return true;
        }
        private async Task LoadPageAsync()
        {
            var url = $"api/parametros/totalPages";
            if (!string.IsNullOrEmpty(Filter))
            {
                url += $"?filter={Filter}";
            }

            var responseHttp = await Repository.GetAsync<int>(url);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            totalPages = responseHttp.Response;
        }

        private async Task CleanFilterAsync()
        {
            Filter = string.Empty;
            await ApplyFilterAsync();
        }

        private async Task ApplyFilterAsync()
        {
            int page = 1;
            await LoadAsync(page);
            await SelectedPageAsync(page);
        }

        private async Task DeleteAsycn(Parametro parametro)
        {
            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmacion",
                Text = $"¿Esta seguro de borrar el pais: {parametro.Nombre}?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
            });
            var confirm = string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }
            var responseHttp = await Repository.DeleteAsync<Parametro>($"api/parametros/{parametro.Id}");

            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/parametros");
                }
                else
                {
                    var messsage = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", messsage, SweetAlertIcon.Error);
                }
                return;
            }

            await LoadAsync();

            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000
            });

            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro borrado con éxito.");
        }
    }
}
