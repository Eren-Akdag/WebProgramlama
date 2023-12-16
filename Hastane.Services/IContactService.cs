﻿using Hastane.Utilities;
using Hastane.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Services
{
    public interface IContactService
    {
        PagedResult<ContactViewModel> GetAll(int pageNumber, int pageSize);

        ContactViewModel GetContactById(int ContactId);

        void UpdateContact(ContactViewModel contact);

        void InsertContact(ContactViewModel contact);

        void DeleteContact(int id);
    }
}
