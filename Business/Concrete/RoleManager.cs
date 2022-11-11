using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IRoleDal _roleDal;

        public RoleManager(RoleManager<Role> roleManager, IRoleDal roleDal)
        {
            _roleManager = roleManager;
            _roleDal = roleDal;
        }

        public void Add(Role entity)
        {
            _roleDal.Add(entity);
        }

        public void AddAsync(Role role)
        {
            _roleManager.CreateAsync(role);
        }

        public void Delete(Role entity)
        {
            _roleDal.Delete(entity);
        }

        public void DeleteAsync(Role role)
        {
            _roleManager.UpdateAsync(role);
        }

        public Role GetById(int id)
        {
            return _roleDal.GetById(id);
        }

        public List<Role> GetList()
        {
            return _roleDal.GetList();
        }

        public void Update(Role entity)
        {
            _roleDal.Update(entity);
        }

        public void UpdateAsync(Role role)
        {
            _roleManager.UpdateAsync(role);
        }
    }
}