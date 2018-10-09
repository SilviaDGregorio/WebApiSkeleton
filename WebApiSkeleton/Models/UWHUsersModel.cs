using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiSkeleton.DTO;
using WebApiSkeleton.Models.Interfaces;

namespace WebApiSkeleton.Models
{
    public class UWHUsersModel : IUWHUsersModel
    {
        private readonly AutoMapper.IMapper _mapper;

        //Remove  when you have a dal o domain who provides this information
        public static List<UWHUsersBD> _usersBd = new List<UWHUsersBD>();

        public UWHUsersModel(AutoMapper.IMapper mapper) {
            _mapper = mapper;
            _usersBd = new List<UWHUsersBD>()
            {
                new UWHUsersBD(){Id = 1, Group ="ISB",Name = "Silvia De Gregorio", Number = 15, Position = "Forward"},
                new UWHUsersBD(){Id = 2, Group ="UWH Madrid",Name = "Andrea Díez", Number = 5, Position = "Forward"},
                new UWHUsersBD(){Id = 3, Group ="UWH Madrid",Name = "Clara Martínez", Number = 9, Position = "Center"},
                new UWHUsersBD(){Id = 5, Group ="UWH Madrid",Name = "Elena Martínez ", Number = 15, Position = "FullBack"},
                new UWHUsersBD(){Id = 6, Group ="UWH Madrid",Name = "Alba Vera", Number = 1, Position = "Wing"},
                new UWHUsersBD(){Id = 7, Group ="UWH Madrid",Name = "Marta Lorente-Sorolla", Number = 11, Position = "Wing"},
                new UWHUsersBD(){Id = 8, Group ="UWH Madrid",Name = "Esther Zugasti", Number = 10, Position = "Forward"},
                new UWHUsersBD(){Id = 9, Group ="UWH Madrid",Name = "Merche Antón", Number = 13, Position = "Wing"},
                new UWHUsersBD(){Id = 10, Group ="UWH Sevilla",Name = "Patricia Marco", Number = 12, Position = "Wing"},
                new UWHUsersBD(){Id = 11, Group ="UWH Sevilla",Name = "Zaida Zurbano", Number = 4, Position = "Forward"}
            };
        }
        public async Task<bool> Delete(int id)
        {
            if(ExistUser(id))
            {
                _usersBd.Remove(_usersBd.Find(userBd => userBd.Id.Equals(id)));
                return !ExistUser(id);
            }
            else return true;           
        }

        public async Task<List<UWHUsers>> Get()
        {
           return  _mapper.Map<List<UWHUsers>>(_usersBd);
        }

        public async Task<UWHUsers> Get(int id)
        {
            DTO.UWHUsersBD userBd = _usersBd.Find(user => user.Id == id);
            return  _mapper.Map<UWHUsers>(userBd);
        }

        public async Task<List<UWHUsers>> Save(List<UWHUsers> userList)
        {            
            List<UWHUsersBD> usersBd = _mapper.Map<List<UWHUsersBD>>(userList) ;
            _usersBd.AddRange(usersBd);
            return  _mapper.Map<List<UWHUsers>>(_usersBd);
        }

        public async Task<UWHUsers> Update(int id, UWHUsers user)
        {
            if(ExistUser(id)) _usersBd.Remove(_usersBd.Find(userBd => userBd.Id.Equals(id)));
            _usersBd.Add(_mapper.Map<UWHUsersBD>(user));
            return _mapper.Map<UWHUsers>(_usersBd.Find(userBd => userBd.Id.Equals(id)));
        }

        private bool ExistUser(int id)
        {
            return _usersBd.Exists(userBd => userBd.Id.Equals(id));
        }
    }
}
