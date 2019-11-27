using System;
using System.Collections.Generic;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators.DocumentTypeService;
using Host4Travel.Core.DTO.DocumentTypeDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Host4Travel.DAL.Abstract;
using Host4Travel.Entities.Concrete;

namespace Host4Travel.BLL.Concrete
{
    public class DocumentTypeManager:IDocumentTypeService
    {
        private IDocumentTypeDal _documentTypeDal;
        private IMapper _mapper;
        private IExceptionHandler _exceptionHandler;

        public DocumentTypeManager(IDocumentTypeDal documentTypeDal, IMapper mapper, IExceptionHandler exceptionHandler)
        {
            _documentTypeDal = documentTypeDal;
            _mapper = mapper;
            _exceptionHandler = exceptionHandler;
        }
        public List<DocumentTypeListDto> GetAll()
        {
            var entities = _documentTypeDal.GetList();
            if (entities==null)
            {
                return null;
            }

            var mappedEntities = _mapper.Map<List<DocumentTypeListDto>>(entities);
            return mappedEntities;
        }

        public DocumentTypeListDto GetById(int id)
        {
            var entity = _documentTypeDal.Get(x=>x.DocumentTypeId==id);
            if (entity==null)
            {
                return null;
            }

            var mappedEntity = _mapper.Map<DocumentTypeListDto>(entity);
            return mappedEntity;
        }

        public void Add(DocumentTypeAddDto model)
        {
            try
            {
                AddDocumentTypeValidator validator=new AddDocumentTypeValidator();
                var validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (_documentTypeDal.IsExists(x=>x.DocumentTypeName==model.DocumentTypeName))
                    {
                        throw new UniqueConstraintException("Zaten bu isimde bir document type mevcut.");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<DocumentType>(model);
                        _documentTypeDal.Add(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void Update(DocumentTypeUpdateDto model)
        {
            try
            {
                UpdateDocumentTypeValidator validator=new UpdateDocumentTypeValidator();
                var validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (!_documentTypeDal.IsExists(x=>x.DocumentTypeId==model.DocumentTypeId))
                    {
                        throw new NullReferenceException();
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<DocumentType>(model);
                        _documentTypeDal.Update(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void Delete(DocumentTypeDeleteDto model)
        {
            try
            {
                DeleteDocumentTypeValidator validator=new DeleteDocumentTypeValidator();
                var validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (!_documentTypeDal.IsExists(x=>x.DocumentTypeId==model.DocumentTypeId))
                    {
                        throw new NullReferenceException();
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<DocumentType>(model);
                        _documentTypeDal.Delete(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }
    }
}