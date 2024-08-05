
namespace BT.Core.Helpers
{
	public static class ViewHelpers
	{

		private static string baseUrl = "../img/assets/";
		public static string GetCategoryIconUrl(string iconName) { 
			return $"{baseUrl}category/{iconName}"; ;
		}
	}
}
