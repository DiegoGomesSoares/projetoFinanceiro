using Financas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Financas.DAO
{
    public class UsuarioDAO
    {
        private FinancasContexto context;

        public UsuarioDAO(FinancasContexto context)
        {
            //foi adicionado a package de injecao de dependencia PM> install-package ninject.mvc3 -version 3.2.1,
            //para usar um mesmo contexto por requisição
            //estão dentro da pasta app-start
            this.context = context;
        }

        public void Adiciona(Usuario usuario)
        {
            context.Usarios.Add(usuario);
            context.SaveChanges();
        }

        public IList<Usuario> Lista()
        {
            return context.Usarios.ToList();
        }
    }
}