using Entities.DTO.EmploymentsDTOS;
using Entities.DTO.ReadedDTOSConfigurations.CountrysConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.DistrictsConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.FilesConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.GenderConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.NeighborhoodConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.StatusConfDTOS;
using Entities.DTO.ReadedDTOSConfigurations.TerritoriesConfDTOS;
using Entities.Model.CountrysModel;
using Entities.Model.DistrictsModel;
using Entities.Model.EmploymentModel;
using Entities.Model.FileModel;
using Entities.Model.GenderModel;
using Entities.Model.NeighborhoodsModel;
using Entities.Model.StatusModel;
using Entities.Model.TerritoriesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.AppealsToRectorDTOS
{
    public class AppealToRectorReadedDTO
    {
        public int id { get; set; }
        public CountryReadedConfDTO country_ { get; set; }
        public TerritorieConfReadedDTO territorie_ { get; set; }
        public DistrictConfReadedDTO? district_ { get; set; }
        public NeighborhoodConfReadedDTO neighborhood_ { get; set; }
        public string addres { get; set; }
        public string fio_ { get; set; }
        public DateTime birthday { get; set; }
        public GenderConfReadedDTO? gender_ { get; set; }
        public EmploymentReadedDTO? employe_ { get; set; }
        public string telephone_number_one { get; set; }
        public string telephone_number_two { get; set; }
        public string email { get; set; }
        public FileConfReadedDTO file_ { get; set; }
        public string appeal { get; set; }
        public bool? confirm { get; set; }
        public DateTime created_at { get; set; }
    }
}
