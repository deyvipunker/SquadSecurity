using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using SquadSecurity.Frontend.Repositories;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Frontend.Pages.Habilitadores
{
    public partial class HabilitadorCreate
    {
        private Habilitador habilitador = new();

        private EditContext editContext = null!;

        public bool FormPostedSuccessfully { get; set; }

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] public SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        protected override void OnInitialized()
        {
            editContext = new(habilitador);
        }

        private async Task CreateAsync()
        {
            habilitador.UsuarioAuditoria = "DSAAVEDRA";
            habilitador.EstadoAuditoria = "ACTIVO";
            habilitador.FechaAuditoria = DateTime.Now;

            var responseHttp = await Repository.PostAsync("api/habilitadores", habilitador);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            await ShowSuccessToast();
            Return();
        }

        private void Return()
        {
            FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("/habilitadores");
        }

        private async Task ShowSuccessToast()
        {
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = false,
                Timer = 3000
            });

            await toast.FireAsync(icon: SweetAlertIcon.Success, title: "Registro creado con éxito.");
        }

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formWasEdited = editContext.IsModified();
            if (!formWasEdited || FormPostedSuccessfully)
            {
                return;
            }

            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmación",
                Text = "¿Deseas abandonar la página y perder los cambios?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Sí",
                CancelButtonText = "No"
            });

            if (result.IsConfirmed)
            {
                return;
            }

            context.PreventNavigation();
        }
    }
}

