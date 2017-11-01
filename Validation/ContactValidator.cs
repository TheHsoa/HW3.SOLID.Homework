using System;
using HomeWork.Infrastructure.Logger;
using HomeWork.Model.Contact;

namespace HomeWork.Validation
{
    // разбить на 2 разных валидатора
    internal class ContactValidator : IValidator<Phone>
    {
        private readonly ILogger _logger;
        public ContactValidator(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsValid(Phone entity)
        {
            try
            {
                return entity.PhoneCode != null && entity.Value != null;
            }
            catch (Exception e)
            {
                _logger.Log(e);
            }
            return true;
        }

        public bool IsValid(Email entity)
        {
            try
            {
                return !string.IsNullOrWhiteSpace(entity.Value);
            }
            catch (Exception e)
            {
                _logger.Log(e);
            }
            return true;
        }
    }
}
