using AutoMapper;
using Core.Dto;
using Core.Entity;
using Core.Repositories;
using Core.Service;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class WordService : GenericService<Word>, IWordService
    { 
        public WordService(IGenericRepository<Word> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
