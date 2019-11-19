namespace Host4Travel.BLL.Abstract
{
    public interface ICrpytoService
    {
        string Encrypt(string input);
        string Decrypt(string cipherText);
    }
}