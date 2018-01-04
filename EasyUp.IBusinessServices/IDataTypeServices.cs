using EasyUp.BusinessEntity;
using System.Collections.Generic;

namespace EasyUp.IBusinessServices
{
    public interface IDataTypeServices
    {
        DataTypeEntity GetDataTypeById(int dataTypeId);
        IEnumerable<DataTypeEntity> GetAllDataTypes();
        int CreateDataType(DataTypeEntity dataTypeEntity);
        bool UpdateDataType(int DataTypeId, DataTypeEntity dataTypeEntity);
        bool DeleteDataType(int dataTypeId);
    }
}
