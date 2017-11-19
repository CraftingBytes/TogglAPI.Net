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
    /// <summary>
    /// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#workspaces
    /// </summary>
    public class WorkspaceService : IWorkspaceService
    {
		private IApiService TogglSrv { get; set; }

        public WorkspaceService(string apiKey)
            : this(new ApiService(apiKey))
        {

        }

        public WorkspaceService(IApiService srv)
        {
            TogglSrv = srv;
        }

        public List<Workspace> List()
        {
            return TogglSrv.Get(ApiRoutes.Workspace.ListWorkspaceUrl).GetData<List<Workspace>>();
        }
        
        public List<User> Users(int workspaceId)
        {
            var url = string.Format(ApiRoutes.Workspace.ListWorkspaceUsersUrl, workspaceId);
            return TogglSrv.Get(url).GetData<List<User>>();
        }

       
        public List<Client> Clients(int workspaceId)
        {
            var url = string.Format(ApiRoutes.Workspace.ListWorkspaceClientsUrl, workspaceId);
            return TogglSrv.Get(url).GetData<List<Client>>();
        }

        public List<Project> Projects(int workspaceId)
        {
            var url = string.Format(ApiRoutes.Workspace.ListWorkspaceProjectsUrl, workspaceId);
            return TogglSrv.Get(url).GetData<List<Project>>();
        }


        public List<Task> Tasks(int workspaceId)
        {
            var url = string.Format(ApiRoutes.Workspace.ListWorkspaceTasksUrl, workspaceId);
            return TogglSrv.Get(url).GetData<List<Task>>();
        }

        public List<Tag> Tags(int workspaceId)
        {
            var url = string.Format(ApiRoutes.Workspace.ListWorkspaceTagsUrl, workspaceId);
            return TogglSrv.Get(url).GetData<List<Tag>>();
        }
        


    }
}
