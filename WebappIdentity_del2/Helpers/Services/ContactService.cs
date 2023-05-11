using Microsoft.IdentityModel.Tokens;
using WebappIdentity_del2.Helpers.Repositories;
using WebappIdentity_del2.Models.Dtos;
using WebappIdentity_del2.Models.Entities;

namespace WebappIdentity_del2.Helpers.Services
{
    public class ContactService
    {
        private readonly ContactRepository _contactRepo;

        public ContactService(ContactRepository contactRepo)
        {
            _contactRepo = contactRepo;
        }

        public async Task<ContactForm> CreateAsync(ContactFormEntity entity)
        {
           
           var _entity =  await _contactRepo.AddAsync(entity);
            return _entity;
        }

        public async Task<IEnumerable<ContactForm>> GetAllAsync()
        {
            var items = await _contactRepo.GetAllAsync();
            var list = new List<ContactForm>();
            foreach (var item in items)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
