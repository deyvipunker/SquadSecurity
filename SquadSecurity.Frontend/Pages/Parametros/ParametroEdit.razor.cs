using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using SquadSecurity.Frontend.Repositories;
using SquadSecurity.Shared.Entities;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection.Metadata;

namespace SquadSecurity.Frontend.Pages.Parametros
{
    public partial class ParametroEdit
    {
        private Parametro? parametro = new();

        private EditContext editContex = null!;
        public bool FormPostedSuccessfully { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;

        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Parameter] public int Id { get; set; }

        protected override void OnInitialized()
        {
            editContex = new(parametro!);
        }


        protected override async Task OnParametersSetAsync()
        {
            var responseHttp = await Repository.GetAsync<Parametro>($"/api/parametros/{Id}");

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
            }
            else
            {
                parametro = responseHttp.Response;
            }

        }
        private async Task EditAsync()
        {
            var responseHttp = await Repository.PutAsync("/api/parametros", parametro);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message);
                return;
            }

            Return();

            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000
            });

            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Cambios guardado com éxito.");
        }

        private void Return()
        {
            FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("/parametros");
        }
        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formWasEdited = editContex.IsModified();
            if (!formWasEdited || FormPostedSuccessfully)
            {
                return;
            }

            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmacion",
                Text = "¿Deseas abandonar la pagina y perder los cambios?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
            });
            var confirm = !string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }
            context.PreventNavigation();
        }
    }
}
