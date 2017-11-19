using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Toggl.Interfaces;

namespace Toggl.Services
{
    public class ProjectService : IProjectService
    {
        private readonly string ProjectsUrl = ApiRoutes.Project.ProjectsUrl;
        

        private IApiService TogglSrv { get; set; }


        public ProjectService(string apiKey)
            : this(new ApiService(apiKey))
        {

        }

		public ProjectService(IApiService srv)
        {
            TogglSrv = srv;
        }

        /// <summary>
        /// 
        /// https://www.toggl.com/public/api#get_projects
        /// </summary>
        /// <returns></returns>
        public List<Project> List()
        {
            var lstProj = new List<Project>();
            var lstWrkSpc = TogglSrv.Get(ApiRoutes.Workspace.ListWorkspaceUrl).GetData<List<Workspace>>();
            lstWrkSpc.ForEach(e =>
                {
                    var projs = ForWorkspace(e.Id.Value);
                    lstProj.AddRange(projs);
                });
            return lstProj;
        }
        
        public List<Project> ForWorkspace (int id)
        {
            var url = string.Format(ApiRoutes.Workspace.ListWorkspaceProjectsUrl, id);
            return TogglSrv.Get(url).GetData<List<Project>>();
        }

	    public List<Project> ForClient(Client client)
	    {
		    if (!client.Id.HasValue)
				throw new InvalidOperationException("Client Id not set");
		    
			return ForClient(client.Id.Value);
	    }

        public List<Project> ForClient(int id)
        {
            var url = string.Format(ApiRoutes.Client.ClientProjectsUrl, id);
            return TogglSrv.Get(url).GetData<List<Project>>();
        }

        public Project Get(int id)
        {
            return List().Where(w => w.Id == id).FirstOrDefault();
        }

        public Project Add(Project project)
        {

            return TogglSrv.Post(ProjectsUrl, project.ToJson()).GetData<Project>();
        }

	    public bool Delete(int id)
	    {
		    var url = string.Format(ApiRoutes.Project.DetailUrl, id);
		    var rsp = TogglSrv.Delete(url);

		    return rsp.StatusCode == HttpStatusCode.OK;
	    }

	    public bool DeleteIfAny(int[] ids)
	    {
		    if (!ids.Any() || ids == null)
				return true;
		    return Delete(ids);
	    }

		public bool Delete(int[] ids)
		{
			if (!ids.Any() || ids == null)
				throw new ArgumentNullException("ids");

			var url = string.Format(
				ApiRoutes.Project.ProjectsBulkDeleteUrl,
				string.Join(",", ids.Select(id => id.ToString()).ToArray()));

			var rsp = TogglSrv.Delete(url);

			return rsp.StatusCode == HttpStatusCode.OK;
		}    
       
    }
}
