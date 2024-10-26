using AutoMapper;
using billboard.Model;
using billboard.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Security;

namespace billboard.services
{
    public interface IPermissionService
    {
        Task<ICollection<Permission>> GetAllPermissionsAsync();
        Task<Permission> GetPermissionByIdAsync(int id);
        Task<Permission> CreatePermissionAsync(Permission permission);
        Task<Permission> UpdatePermissionAsync(Permission permission);
        Task DeletePermissionAsync(int id);
    }

    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<Permission> CreatePermissionAsync(Permission permission)
        {
            return await _permissionRepository.CreatePermissionAsync(permission);
        }

        public Task<Permission> GetPermissionByIdAsync(int id)
        {
            return _permissionRepository.GetPermissionByIdAsync(id);
        }

        public async Task<Permission> UpdatePermissionAsync(Permission permission)
        {
            return await _permissionRepository.UpdatePermissionAsync(permission);
        }

        public async Task DeletePermissionAsync(int id)
        {
            await _permissionRepository.DeletePermissionAsync(id);
        }

        public async Task<ICollection<Permission>> GetAllPermissionsAsync()
        {
            return await _permissionRepository.GetAllPermissionsAsync();
        }
    }
}
