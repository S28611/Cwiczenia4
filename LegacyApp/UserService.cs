using System;

namespace LegacyApp
{
    public class UserService
    {
        private IClientRepository _clientRepository;
        private IUserCreditService _userCreditService;

        public UserService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            _userCreditService = new UserCreditService();
        }

        public UserService(IClientRepository clientRepository, IUserCreditService userCreditService)
        {
            _clientRepository = clientRepository;
            _userCreditService = userCreditService;
        }

        public UserService()
        {
            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {

            var client = _clientRepository.GetById(clientId);
            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (!user.NameIsNull())
            {
                return false;
            }
            
            if (!user.EmailValidation())
            {
                return false;
            }
            
            if (!user.OlderThan21(dateOfBirth))
            {
                return false;
            }
            
            DefineCreditLimit(user,client);

            if (!ValidateCreditLimitToHave(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        private void DefineCreditLimit(User user, Client client)
        {
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            
            else if (client.Type == "ImportantClient")
            {
                user.HasCreditLimit = true;// missing part from begin
                int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth); 
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
            else
            {
                user.HasCreditLimit = true;
                int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth); 
                user.CreditLimit = creditLimit;
            }
        }

        private bool ValidateCreditLimitToHave(User user)
        {
            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }
            
            return true;
        }
    }
}
