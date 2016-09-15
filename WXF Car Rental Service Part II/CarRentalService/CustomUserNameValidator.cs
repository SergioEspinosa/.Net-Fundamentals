using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace CarRentalService
{
    public class CustomUserNameValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                throw new FaultException("Empty credentials");
            }

            if (!(userName == "alex" && password == "123456"))
            {
                throw new FaultException("Unknown Username or Incorrect Password");
            }
        }
    }
}
