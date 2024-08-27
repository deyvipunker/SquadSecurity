using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using SquadSecurity.Frontend.Repositories;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Frontend.Pages.Parametros
{
    public partial class ParametroCreate
    {
        private Parametro parametro = new();

        private EditContext editContex = null!;

        public bool FormPostedSuccessfully { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] public SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        protected override void OnInitialized()
        {
            editContex = new(parametro);
        }

        private async Task CreateAsysnc()
        {
            parametro.UsuarioAuditoria = "DSAAVEDRA";
            parametro.EstadoAuditoria = "ACTIVO";
            parametro.FechaAuditoria = DateTime.Now;
            var responseHttp = await Repository.PostAsync("api/parametros", parametro);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
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

            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro creado com éxito.");
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
