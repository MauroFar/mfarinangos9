using mfarinangos9.Models;

namespace mfarinangos9.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

	private void btnListar_Clicked(object? sender, EventArgs e)
    {
		List<Persona> people = App._personRepo.GetAllPerson();
		ListaPersonas.ItemsSource = people;
		lblStatusMessage.Text = people.Count == 0
			? "No hay personas guardadas."
			: $"Personas encontradas: {people.Count}";
    }
	private void btnAgregar_Clicked(object? sender, EventArgs e)
	{
		lblStatusMessage.Text = "";
		App._personRepo.AddNewPerson(txtName.Text);
		lblStatusMessage.Text = App._personRepo.StatusMessage;
		txtName.Text = string.Empty;
    }

	private void btnEliminar_Clicked(object? sender, EventArgs e)
	{
		if (sender is not Button button || button.BindingContext is not Persona person)
		{
			return;
		}

		App._personRepo.DeletePerson(person.Id);
		lblStatusMessage.Text = App._personRepo.StatusMessage;
		btnListar_Clicked(null, EventArgs.Empty);
	}
}