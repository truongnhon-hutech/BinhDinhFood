namespace BinhDinhFoodWeb.Intefaces
{
    public interface ITokenRepository
    {
        public bool CheckToken(string userName, string token);
    }
}
