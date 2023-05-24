namespace knightApp.Entities
{
    public partial class Athletes
    {
        public string FIO => $"{lastname} {firstname} {patronymic}";
    }
}
