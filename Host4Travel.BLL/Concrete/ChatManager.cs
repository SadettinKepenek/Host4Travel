using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete;
using Host4Travel.Core.BLL.Concrete.EntityService;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class ChatManager:IChatService
    {
        private IChatDal _chatDal;

        public ChatManager(IChatDal chatDal)
        {
            _chatDal = chatDal;
        }

        public Chat Get(Expression<Func<Chat, bool>> filter = null)
        {
            return null;
        }

        public List<Chat> GetAll(Expression<Func<Chat, bool>> filter = null)
        {
            return null;
        }

        public ResultModel Add(Chat entity)
        {
            return null;
        }

        public ResultModel Update(Chat entity)
        {
            return null;
        }

        public ResultModel Delete(Chat entity)
        {
            return null;
        }
    }
}