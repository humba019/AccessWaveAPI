using AccessWave.Domain.Models;
using AccessWave.Persistence.Repositories.Interface;
using AccessWave.Services.Communications;
using AccessWave.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> DeleteAsync(string username)
        {
            try
            {
                var exist = await _userRepository.FindByIdAsync(username);
                UserResponse response = exist == null ? new UserResponse($"User {username} not found") : new UserResponse(exist);

                _userRepository.Remove(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred when deleting the user: { e.Message }");
            }
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred when saving the user: {e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(string username, User user)
        {
            try
            {
                var exist = await _userRepository.FindByIdAsync(username);
                UserResponse response = exist == null ? new UserResponse($"User {username} not found") : new UserResponse(exist);

                exist.UserName = user.UserName != "" ? user.UserName : exist.UserName;

                exist.UserPass = user.UserPass != "" ? user.UserPass : exist.UserPass;

                exist.FullName = user.FullName != "" ? user.FullName : exist.FullName;

                exist.LastAccess = user.LastAccess != "" ? user.LastAccess : exist.LastAccess;

                exist.CodeRule = user.CodeRule != 0 ? user.CodeRule : exist.CodeRule;

                _userRepository.Update(exist);
                await _unitOfWork.CompleteAsync();

                return response;
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred when updating the user: { e.Message }");
            }
        }
    }
}
