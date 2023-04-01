using AutoMapper;
using WebApplication6.BL.helper;
using WebApplication6.BL.Interfaces;
using WebApplication6.DAL.Database;
using WebApplication6.DAL.Entities;
using WebApplication6.Models;

namespace WebApplication6.BL.Repository
{
    public class FilesRep : IFiles
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public FilesRep(DbContainer db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void Add(FilesVM F)
        {
            var data = mapper.Map<Files>(F);
            data.PhotoName = UploadFile.SaveFile(F.PhotoUrl, "Photos");
            db.Files.Add(data);
            db.SaveChanges();
        }
    }
}
