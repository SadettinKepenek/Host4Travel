﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.BLL.Abstract;
using Host4Travel.DAL.Abstract;
using Host4Travel.Entities.Concrete;
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

        public void Add(Chat entity)
        {
        }

        public void Update(Chat entity)
        {
        }

        public void Delete(Chat entity)
        {
        }
    }
}