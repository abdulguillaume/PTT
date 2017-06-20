﻿using PersonalProjectPTT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalProjectPTT.Models;


//using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using System.IO;
//using System.Net.Http;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Authorization;


namespace PersonalProjectPTT.Services
{
    public class ProjectService : IProjectService
    {
        private IGenericRepository _repo;

        public ProjectService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public void AddProject(Project project)
        {
            ClientService cs = new ClientService(_repo);

            Client client = null;

            if (project.Customer.Id != 0)
            {
                client = cs.GetClient(project.Customer.Id);
                project.Customer = client;
            }

            _repo.Add(project);
        }

        public List<Project> AllProjects()
        {
            List<Project> projects = (from p in _repo.Query<Project>().Include(a => a.Tasks)
                                      select p
                                        ).ToList();


            //List<Project> projects = (from p in _repo.Query<Project>()
            //                          select new Project {

            //                          }
            //                            ).ToList();

            return projects;
        }

        public void DeleteProject(int id)
        {
            Project toDelete = GetProject(id);
            _repo.Delete(toDelete);
        }

        public Project GetProject(int id)
        {
            Project project = (from p in _repo.Query<Project>().Include(a=>a.Tasks)
                          where p.Id == id
                          select p
                          ).FirstOrDefault();
            return project;
        }

        public void UpdateProject(Project project)
        {
            _repo.Update(project);
        }
    }
}
