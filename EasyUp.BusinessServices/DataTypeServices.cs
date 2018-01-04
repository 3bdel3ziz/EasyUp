using AutoMapper;
using EasyUp.BusinessEntity;
using EasyUp.Core;
using EasyUp.IBusinessServices;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace EasyUp.BusinessServices
{
    public class DataTypeServices : IDataTypeServices
    {
        private readonly UnitOfWork _unitOfWork;

        public DataTypeServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public DataTypeEntity GetDataTypeById(int dataTypeId)
        {
            var dataType = _unitOfWork.DataTypeRepository.GetByID(dataTypeId);

            if (dataType != null)
            {
                Mapper.CreateMap<DataType, DataTypeEntity>();

                return Mapper.Map<DataType, DataTypeEntity>(dataType);
            }
            return null;
        }

        /// <summary>
        /// Fetches all the DataTypes.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataTypeEntity> GetAllDataTypes()
        {
            var DataTypes = _unitOfWork.DataTypeRepository.GetAll().ToList();
            if (DataTypes.Any())
            {
                Mapper.CreateMap<DataType, DataTypeEntity>();
                var DataTypesModel = Mapper.Map<List<DataType>, List<DataTypeEntity>>(DataTypes);
                return DataTypesModel;
            }
            return null;
        }

        /// <summary>
        /// Creates a DataType
        /// </summary>
        /// <param name="DataTypeEntity"></param>
        /// <returns></returns>
        public int CreateDataType(DataTypeEntity DataTypeEntity)
        {
            using (var scope = new TransactionScope())
            {
                var DataType = new DataType
                {
                    DataTypeName = DataTypeEntity.DataTypeName
                };
                _unitOfWork.DataTypeRepository.Insert(DataType);
                _unitOfWork.Save();
                scope.Complete();
                return DataType.DataTypeId;
            }
        }

        /// <summary>
        /// Updates a DataType
        /// </summary>
        /// <param name="DataTypeId"></param>
        /// <param name="DataTypeEntity"></param>
        /// <returns></returns>
        public bool UpdateDataType(int DataTypeId, DataTypeEntity DataTypeEntity)
        {
            var success = false;
            if (DataTypeEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var DataType = _unitOfWork.DataTypeRepository.GetByID(DataTypeId);
                    if (DataType != null)
                    {
                        DataType.DataTypeName = DataTypeEntity.DataTypeName;
                        _unitOfWork.DataTypeRepository.Update(DataType);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>
        /// Deletes a particular DataType
        /// </summary>
        /// <param name="DataTypeId"></param>
        /// <returns></returns>
        public bool DeleteDataType(int DataTypeId)
        {
            var success = false;
            if (DataTypeId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var DataType = _unitOfWork.DataTypeRepository.GetByID(DataTypeId);
                    if (DataType != null)
                    {

                        _unitOfWork.DataTypeRepository.Delete(DataType);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
