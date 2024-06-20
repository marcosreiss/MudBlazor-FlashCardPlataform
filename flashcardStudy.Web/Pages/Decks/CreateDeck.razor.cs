using flascardStudy.Core.Handler;
using flascardStudy.Core.Requests.Deck;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace flashcardStudy.Web.Pages.Decks
{
    public partial class CreateDeckPage : ComponentBase
    {
        #region Props

        public bool IsBusy { get; set; } = false;
        public CreateDeckRequest InputModel { get; set; } = new();

        #endregion

        #region Services

        [Inject]
        public IDeckHandler Handler { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!; //para navegar entre as páginas
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        #endregion

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;
            try
            {
                var result = await Handler.CreateAsync(InputModel);
                if (result.IsSuccess) { 
                    Snackbar.Add(result.Message, Severity.Success);
                    NavigationManager.NavigateTo("/");
                }
                else Snackbar.Add(result.Message, Severity.Error);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally { IsBusy = false; }
        }

        #endregion

    }
}
