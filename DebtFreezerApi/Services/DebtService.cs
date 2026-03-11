using DebtFreezerApi.Dtos;
using DebtFreezerApi.Exceptions;
using DebtFreezerApi.Models;
using DebtFreezerApi.Repositories;
using DebtFreezerApi.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebtFreezerApi.Services
{
    public class DebtService : IDebtService


    {

        private readonly IRepository<Debt> _repository;
        private readonly IUSerRepository _userRepository;


        public DebtService(IRepository<Debt> repository, IUSerRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<DebtDto> CreateAsync(CreateDebtDto dto)
        {
            if (! await  _userRepository.ExistsAsync(dto.UserId))
            {
                 throw new NotFoundException($"User avec l'id {dto.UserId} non trouvé !");
            }

            User utilisateur  =  await _userRepository.GetByIdAsync(dto.UserId);

            Debt debt = new Debt()
            {
                Creditor = dto.Creditor,

                OriginalAmount = dto.OriginalAmount,

                RemainingAmount = dto.RemainingAmount,

                InterestRate = dto.InterestRate,

                DueDate = dto.DueDate,

                Type = dto.Type,

                Status = DebtStatus.ACTIVE,
                UserId  =  dto.UserId,
                User =  utilisateur
            };

            await _repository.CreateAsync(debt);
            return new DebtDto()
            {
                     Id =  debt.Id,

                    Creditor =  debt .Creditor,

                    OriginalAmount =  debt.OriginalAmount,

                    RemainingAmount = debt.RemainingAmount,

                    InterestRate =   debt.InterestRate,

                    DueDate =  debt.DueDate,

                    Type =  debt.Type,
                    Status =  debt.Status,
                    User  =  debt.User


            };

          
        }




        public async Task<bool> DeleteAsync(int id)
        {
            Debt dette =  await _repository.GetByIdAsync(id);
            if (dette ==  null)
            {
                throw new NotFiniteNumberException($"Impossible de supprimer : La dette {id} est introuvable.");
                
            }
            await _repository.DeleteAsync(id);
            return true;

        }



        public async Task<List<DebtDto>> GetAllAsync()
        {
            List<DebtDto> nListe =  new List<DebtDto>();
            var dettes = await _repository.GetAllAsync();
            foreach ( Debt dette in dettes )
            {
                DebtDto debtDto = new DebtDto()
                {
                    Id = dette.Id,

                    Creditor = dette.Creditor,

                    OriginalAmount = dette.OriginalAmount,

                    RemainingAmount = dette.RemainingAmount,

                    InterestRate = dette.InterestRate,

                    DueDate = dette.DueDate,

                    Type = dette.Type,
                    Status = dette.Status,
                    User = dette.User

                };
                nListe.Add(debtDto);

            }
            return nListe;

        }




        public async Task<DebtDto> GetByIdAsync(int id)
        {

            Debt dette =  await _repository.GetByIdAsync(id);

            return new DebtDto()
            { Id = dette.Id, Creditor = dette.Creditor, OriginalAmount = dette.OriginalAmount, RemainingAmount = dette.RemainingAmount,
            InterestRate = dette.InterestRate,
            DueDate = dette.DueDate,
            Type = dette.Type,
            Status = dette.Status,
            User = dette.User
            };

        }




        public async Task<bool> UpdateAsync(int id, UpdateDebtDto dto)
        {
            Debt dette = await _repository.GetByIdAsync(id);
            if(dette ==  null)
            {
                throw new NotFoundException($"Impossible de modifier ! La dette {id} n'existe pas");
            }

            dette.Creditor = dto.Creditor;

            dette.OriginalAmount = dto.OriginalAmount;

            dette.RemainingAmount = dto.RemainingAmount;

            dette.InterestRate = dto.InterestRate;

            dette.DueDate = dto.DueDate;

            dette.Type = dto.Type;
            dette.UserId = dto.UserId;

            await _repository.UpdateAsync(dette);
            return true;
 

    }
    }
}
