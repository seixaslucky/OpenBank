using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using OpenBank.Domain.Entities;
using OpenBank.Domain.Interfaces;
using OpenBank.Domain.Interfaces.Service;

namespace OpenBank.Service.Services {
    public class AccountService : IAccountService {
        private IRepository<Account> _repository;
        private IRepository<Movement> _repositoryTransaction;
        public AccountService (IRepository<Account> repository, IRepository<Movement> repositoryTransaction) {
            _repository = repository;
            _repositoryTransaction = repositoryTransaction;
        }
        public async Task<bool> Delete (Guid id) {
            return await _repository.RemoveAsync (id);
        }

        public async Task<Account> Get (Guid id) {
            return await _repository.SelectAsync (id);
        }

        public async Task<IEnumerable<Account>> GetAll () {
            return await _repository.SelectAsync ();
        }

        public async Task<Account> Post (Account account) {
            //guarantee  that an account will always start with a balance equal to zerro
            //and any value that goes in or out exists in db;
            account.Balance = 0;
            return await _repository.InsertAsync (account);
        }

        public async Task<Account> Put (Account account) {
            var result = await _repository.SelectAsync (account.Id);
            if (result != null) {
                //Balance can only be updated by deposit or withdraw
                account.Balance = result.Balance;
                return await _repository.UpdateAsync (account);
            } else {
                throw new ArgumentException ("Cant Find Account");
            }

        }

        //todo test transactions db methods
        public async Task<Account> Withdraw (Guid id, decimal value) {
            try {
                Movement transaction = new Movement {
                    IdAccount = id,
                    Type = 0,
                    Value = value,
                    Success = false
                };

                if (value < 0) {
                    throw new ArgumentException ("Cannot withdraw negative amount");
                }
                var result = await _repository.SelectAsync (id);
                if (result == null) {
                    throw new ArgumentException ("Account not found");
                }
                if (result.Balance - value < 0) {
                    throw new ArgumentException ("not enough Balance");
                }
                result.Balance -= value;
                var update = await _repository.UpdateAsync (result);

                if (update == null) {
                    var resultTransaction = await _repositoryTransaction.InsertAsync (transaction);
                    return update;
                } else {
                    transaction.Success = true;
                    var resultTransaction = await _repositoryTransaction.InsertAsync (transaction);
                    return update;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        //todo test transactions db methods
        public async Task<Account> Deposit (Guid id, decimal value) {
            try {
                Movement transaction = new Movement {
                    IdAccount = id,
                    Type = 1,
                    Value = value,
                    Success = false
                };

                if (value < 0) {
                    throw new ArgumentException ("Cannot deposit negative amount");
                }
                var result = await _repository.SelectAsync (id);
                if (result == null) {
                    throw new ArgumentException ("Account not found");
                }
                result.Balance += value;
                var update = await _repository.UpdateAsync (result);
                if (update == null) {
                    var resultTransaction = await _repositoryTransaction.InsertAsync (transaction);
                    return update;
                } else {
                    transaction.Success = true;
                    var resultTransaction = await _repositoryTransaction.InsertAsync (transaction);
                    return update;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}