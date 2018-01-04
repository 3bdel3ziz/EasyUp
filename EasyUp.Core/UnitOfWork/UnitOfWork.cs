#region Using Namespaces...

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
 

#endregion

namespace EasyUp.Core
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private EasyUpDbContext _context = null;
        private GenericRepository<ContentType> _contentTypeRepository;
        private GenericRepository<ContentField> _contentFieldRepository;
        private GenericRepository<ContentFieldValue> _contentFieldValueRepository;
        private GenericRepository<DataType> _dataTypeRepository;

        #endregion

        public UnitOfWork()
        {
            _context = new EasyUpDbContext();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        public GenericRepository<ContentType> ContentTypeRepository
        {
            get
            {
                if (this._contentTypeRepository == null)
                    this._contentTypeRepository = new GenericRepository<ContentType>(_context);
                return _contentTypeRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<ContentField> ContentFieldRepository
        {
            get
            {
                if (this._contentFieldRepository == null)
                    this._contentFieldRepository = new GenericRepository<ContentField>(_context);
                return _contentFieldRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<DataType> DataTypeRepository
        {
            get
            {
                if (this._dataTypeRepository == null)
                    this._dataTypeRepository = new GenericRepository<DataType>(_context);
                return _dataTypeRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for token repository.
        /// </summary>
        public GenericRepository<ContentFieldValue> ContentFieldValueRepository
        {
            get
            {
                if (this._contentFieldValueRepository == null)
                    this._contentFieldValueRepository = new GenericRepository<ContentFieldValue>(_context);
                return _contentFieldValueRepository;
            }
        }
        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false; 
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}