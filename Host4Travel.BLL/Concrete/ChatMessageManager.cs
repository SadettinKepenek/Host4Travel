using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
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

        public void Add(ChatMessage entity)
        {
        }

        public void Update(ChatMessage entity)
        {
        }

        public void Delete(ChatMessage entity)
        {
        }
    }
}