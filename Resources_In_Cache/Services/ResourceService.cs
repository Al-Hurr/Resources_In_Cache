using Microsoft.Extensions.Caching.Memory;
using Resources_In_Cache.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resources_In_Cache.Services
{
    public class ResourceService
    {
        private readonly IMemoryCache _cache;

        public ResourceService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Create(ResourceCreateModel resourceCreateModel)
        {
            var resource = new Resource
            {
                Id = new Guid(),
                Title = resourceCreateModel.Title
            };
            Add(resource);
        }

        public void Update(Guid id)
        {
            var resource = Get(id);
            Add(resource);
        }

        public Resource Get(Guid id)
        {
            Resource resource = null;
            _cache.TryGetValue(id, out resource);
            return resource;
        }

        public void Remove(Guid id) => _cache.Remove(id);

        private void Add(Resource resource)
        {
            _cache.Set(resource.Id, resource, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15)
            });
        }

        public IEnumerable<Resource> GetAll()
        {
            var resourcesList = new List<Resource>();
            IDictionaryEnumerator cacheEnumerator = (IDictionaryEnumerator)((IEnumerable)_cache).GetEnumerator();
            while (cacheEnumerator.MoveNext())
            {
                resourcesList.Add(new Resource
                {
                    Id = (Guid)cacheEnumerator.Key,
                    Title = cacheEnumerator.Value.ToString()
                }); ;
               // Conosle.WriteLine("{0} : {1}{2}", cacheEnumerator.Key, cacheEnumerator.Value, Environment.NewLine);
            }
            return resourcesList;
        }
    }
}
