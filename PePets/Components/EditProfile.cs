﻿using Microsoft.AspNetCore.Mvc;
using PePets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PePets.Components
{
    public class EditProfile : ViewComponent
    {
        private readonly UserRepository _userRepository;

        public EditProfile(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            User user = await _userRepository.GetUserById(id);
            if (user == null)
                return View();


            EditUserProfileViewModel editUserProfileViewModel = new EditUserProfileViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Location = user.Location,
                Gender = user.Gender,
                Avatar = user.Avatar,
                DateOfBirth = user.DateOfBirth,
                AboutMe = user.AboutMe
            };


            return View("EditProfile", editUserProfileViewModel);
        }
    }
}
