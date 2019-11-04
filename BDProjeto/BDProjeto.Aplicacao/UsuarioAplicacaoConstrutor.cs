﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDProjeto.RepositorioADO;
using BDProjeto.RepositorioEF;

namespace BDProjeto.Aplicacao
{
    public class UsuarioAplicacaoConstrutor
    {
        public static UsuarioAplicacao UsuarioApADO()
        {
            return new UsuarioAplicacao(new UsuarioAplicacaoADO());
        }

        public static UsuarioAplicacao UsuarioApEF()
        {
            return new UsuarioAplicacao(new UsuarioRepositorioEF());
        }
    }
}
