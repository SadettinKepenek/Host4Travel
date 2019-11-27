using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Validators.DocumentService;
using Host4Travel.Core.DTO.DocumentDtos;
using Host4Travel.Core.ExceptionService.Abstract;
using Host4Travel.Core.ExceptionService.Exceptions;
using Host4Travel.DAL.Abstract;
using Host4Travel.Entities.Concrete;

namespace Host4Travel.BLL.Concrete
{
    public class DocumentManager:IDocumentService
    {
        private IExceptionHandler _exceptionHandler;
        private IDocumentDal _documentDal;
        private IMapper _mapper;

        public DocumentManager(IExceptionHandler exceptionHandler, IDocumentDal documentDal, IMapper mapper)
        {
            _exceptionHandler = exceptionHandler;
            _documentDal = documentDal;
            _mapper = mapper;
        }
        public List<DocumentListDto> GetAll()
        {
            var documents = _documentDal.GetList();
            if (documents==null)
            {
                return null;
            }

            var mappedDocuments = _mapper.Map<List<DocumentListDto>>(documents);
            return mappedDocuments;
        }

        public DocumentListDto GetById(Guid id)
        {
            var document = _documentDal.Get(x => x.DocumentId == id);
            if (document==null)
            {
                return null;
            }

            var mappedDocument = _mapper.Map<DocumentListDto>(document);
            return mappedDocument;
        }

        public void Add(DocumentAddDto model)
        {
            try
            {
                AddDocumentValidator validator=new AddDocumentValidator();
                var validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (_documentDal.IsExists(x=>x.DocumentTypeId==model.DocumentTypeId && x.OwnerId==model.OwnerId))
                    {
                        throw new UniqueConstraintException("Kullanıcı için belirtilen türde döküman zaten var");
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<Document>(model);
                        _documentDal.Add(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void Update(DocumentUpdateDto model)
        {
            try
            {
                UpdateDocumentValidator validator=new UpdateDocumentValidator();
                var validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (!_documentDal.IsExists(x=>x.DocumentId==model.DocumentId))
                    {
                        throw new NullReferenceException();
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<Document>(model);
                        _documentDal.Update(mappedEntity);
                    }
                }
            }
            catch (Exception e)
            {
                throw _exceptionHandler.HandleServiceException(e);
            }
        }

        public void Delete(DocumentDeleteDto model)
        {
            try
            {
                DeleteDocumentValidator validator=new DeleteDocumentValidator();
                var validationResult = validator.Validate(model);
                if (!validationResult.IsValid)
                {
                    throw new ValidationFailureException(validationResult.ToString());
                }
                else
                {
                    if (!_documentDal.IsExists(x=>x.DocumentId==model.DocumentId))
                    {
                        throw new NullReferenceException();
                    }
                    else
                    {
                        var mappedEntity = _mapper.Map<Document>(model);
                        _documentDal.Delete(mappedEntity);
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