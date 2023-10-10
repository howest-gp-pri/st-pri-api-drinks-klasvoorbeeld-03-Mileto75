namespace Pri.Drinks.Web.ViewModels
{
    public class DrinksInfoViewModel : BaseViewModel
    {
        public BaseViewModel Category { get; set; }
        public IEnumerable<BaseViewModel> Properties { get; set; }
        public int AlcoholPercentage { get; set; }
    }
}
