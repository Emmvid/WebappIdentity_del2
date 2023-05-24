using WebappIdentity_del2.Context;
using WebappIdentity_del2.Models.Entities;

namespace WebappIdentity_del2.Helpers.Repositories;

public class ContactRepository : Repo<ContactFormEntity>
{
    public ContactRepository(ApplicationContext context) : base(context)
    {
    }
}
