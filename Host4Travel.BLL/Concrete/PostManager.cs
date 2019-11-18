using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.Core.DTO.PostService;
using Host4Travel.DAL.Abstract;
using Host4Travel.UI;

namespace Host4Travel.BLL.Concrete
{
    public class PostManager : IPostService
    {
        private readonly IPostDal _postDal;
        private IMapper _mapper;

        public PostManager(IPostDal postDal, IMapper mapper)
        {
            _postDal = postDal;
            _mapper = mapper;
        }


        public List<PostListDto> GetAllPosts()
        {
            var posts = _postDal.GetList();
            if (posts==null)
            {
                return null;
            }

            var mappedPosts = _mapper.Map<List<PostListDto>>(posts);
            return mappedPosts;
        }

        public PostDetailDto GetPost(Guid postId)
        {
            var post = _postDal.Get(x=>x.PostId==postId);
            if (post==null)
            {
                return null;
            }

            var mappedPost = _mapper.Map<PostDetailDto>(post);
            return mappedPost;
        }

        public void AddPost(PostAddDto model)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;   
            }
            // TODO
        }

        public void UpdatePost(PostUpdateDto model)
        {
            // TODO
        }

        public void DeletePost(PostDeleteDto model)
        {
            // TODO
        }
    }
}