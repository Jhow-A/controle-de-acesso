using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ControleDeAcesso.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            /* O código abaixo informa ao MVC para incluir todos os arquivos na pasta "Scripts" que tenham a cadeia "jquery" no arquivo, seguida por um "-" e número de versão com a extensão ".js". Também fornece a referência de "~/bundles/jquery", é assim que vamos referenciar o bundle nas views posteriormente   
*/
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-1.9.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/estilo.css"));
        }
    }
}