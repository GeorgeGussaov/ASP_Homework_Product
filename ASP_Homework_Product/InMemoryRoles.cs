using ASP_Homework_Product.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ASP_Homework_Product
{
    public class InMemoryRoles : IRolesRepository
    {
        private List<Role> Roles = new List<Role>();
        public List<Role> GetRoles() { return Roles; }
        public Role TryGetById(Guid id)
        {
            return Roles.FirstOrDefault(r => r.Id == id);
        }
        public void Add(Role role)
        {
            Roles.Add(role);
        }
        public void Delete(Guid id)
        {
            var role = TryGetById(id);
            Roles.Remove(role);
        }
    }

    public interface IRolesRepository
    {
        public List<Role> GetRoles();
        public void Add(Role role);
        public void Delete(Guid id);

	}
}
