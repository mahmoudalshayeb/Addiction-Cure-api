﻿using Addiction_Cure.core.data;
using Addiction_Cure.core.Repository;
using Addiction_Cure.core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Addiction_Cure.infra.Service
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository homeRepository;
        public HomeService(IHomeRepository homeRepository)
        {
            this.homeRepository = homeRepository;
        }
        public List<Homepageac> GetAllhome()
        {
            return homeRepository.GetAllhome();
        }

        public void createhome(Homepageac homepageac)
        {
            homeRepository.createhome(homepageac);
        }
        public void updatehome(Homepageac homepageac)
        {
            homeRepository.updatehome(homepageac);
        }
        public void Deletehome(int hid)
        {
            homeRepository.Deletehome(hid);
        }
    }
}
