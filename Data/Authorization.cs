namespace GimpiesBlazor.Data
{
    public class Authorization
    {
        public const string ViewStock = "ViewStock";
        public const string AddShoe = "AddShoe";
        public const string EditShoe = "EditShoe";
        public const string DeleteShoe = "DeleteShoe";

        public const string ViewAccounts = "ViewAccounts";
        public const string CreateAccount = "CreateAccount";
        public const string EditAccount = "EditAccount";
        public const string DeleteAccount = "DeleteAccount";

        public const string ViewSales = "ViewSales";

        public static List<string> GetPermissions()
        {
            return
            [
                ViewStock,
                AddShoe,
                EditShoe,
                DeleteShoe,
                ViewAccounts,
                CreateAccount,
                EditAccount,
                DeleteAccount,
                ViewSales
            ];
        }
    }
}
