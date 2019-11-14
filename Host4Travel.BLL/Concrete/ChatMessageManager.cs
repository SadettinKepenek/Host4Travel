using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.BLL.Concrete;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class ChatMessageManager:IChatMessageService
    {
        private IChatMessageDal _chatMessageDal;

        public ChatMessageManager(IChatMessageDal chatMessageDal)
        {
            _chatMessageDal = chatMessageDal;
        }
        public ChatMessage Get(Expression<Func<ChatMessage, bool>> filter = null)
        {
            return null;
        }

        public List<ChatMessage> GetAll(Expression<Func<ChatMessage, bool>> filter = null)
        {
            return null;
        }

        public ResultModel Add(ChatMessage entity)
        {
            return null;
        }

        public ResultModel Update(ChatMessage entity)
        {
            return null;
        }

        public ResultModel Delete(ChatMessage entity)
        {
            return null;
        }
    }
}