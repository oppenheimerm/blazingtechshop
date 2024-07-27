using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BT.Admin.Components.Validation
{
	/// <summary>
	/// The form's EditContext is a cascading parameter of the component.
	/// 
	/// When the validator component is initialized, a new ValidationMessageStore 
	/// is created to maintain a current list of form errors.
	/// 
	///	The message store receives errors when developer code in the form's 
	///	component calls the DisplayErrors method. The errors are passed to 
	///	the DisplayErrors method in a Dictionary<string, List<string>>. In 
	///	the dictionary, the key is the name of the form field that has one 
	///	or more errors. The value is the error list.
	///	
	///	Messages are cleared when any of the following have occurred:
	///		- Validation is requested on the EditContext when the 
	///		  OnValidationRequested event is raised. All of the errors 
	///		  are cleared.
	///		-  A field changes in the form when the OnFieldChanged event 
	///		   is raised. Only the errors for the field are cleared.
	///		- The ClearErrors method is called by developer code. All of 
	///		  the errors are cleared.
	///		  
	/// </summary>
	public class CustomValidation : ComponentBase
	{
		private ValidationMessageStore? messageStore;

		[CascadingParameter]
		private EditContext? CurrentEditContext { get; set; }

		protected override void OnInitialized()
		{
			if (CurrentEditContext is null)
			{
				throw new InvalidOperationException(
					$"{nameof(CustomValidation)} requires a cascading " +
					$"parameter of type {nameof(EditContext)}. " +
					$"For example, you can use {nameof(CustomValidation)} " +
					$"inside an {nameof(EditForm)}.");
			}

			messageStore = new(CurrentEditContext);

			CurrentEditContext.OnValidationRequested += (s, e) =>
				messageStore?.Clear();
			CurrentEditContext.OnFieldChanged += (s, e) =>
				messageStore?.Clear(e.FieldIdentifier);
		}

		public void DisplayErrors(Dictionary<string, List<string>> errors)
		{
			if (CurrentEditContext is not null)
			{
				foreach (var err in errors)
				{
					messageStore?.Add(CurrentEditContext.Field(err.Key), err.Value);
				}

				CurrentEditContext.NotifyValidationStateChanged();
			}
		}

		public void ClearErrors()
		{
			messageStore?.Clear();
			CurrentEditContext?.NotifyValidationStateChanged();
		}	
	}
}
