using ControleDeAcesso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ControleDeAcesso.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// Método responsável por redirecionar para a View de acesso.
        /// </summary>
        /// <param name="returnURL"> Armazena qual é a URL atual para ser redirecionado após a autenticação.</param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl)
        {
            // Recebe a url que o usuário tentou acessar
            ViewBag.ReturnUrl = returnUrl;
            return View(new Acesso());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Acesso acesso, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (DevMediaEntities db = new DevMediaEntities())
                {
                    // Recupera os dados da tabela de Acesso, que é retornado após a condição Where. Como parâmetro é usado a variavel acesso, que é o retorno da tela de login.
                    var login = db.Acesso.Where(p => p.email.Equals(acesso.email)).FirstOrDefault();

                    // Verifica se usuário existe
                    if (login != null)
                    {
                        // Verifica se o usuário está ativo. Obs.: Um exemplo de ValidationSummary é trocar "S" por 'S', uma mensagem de erro voltará para a tela
                        if (Equals(login.ativo, "S"))
                        {
                            // Verifica se as senhas são iguais
                            if (Equals(login.senha, acesso.senha))
                            {
                                /* Caso o usuário e senha estejam validados e o usuário esteja ativo, ele faz a autenticação do usuário gravando no Cookie a senha do usuário e o parâmetro "false" para que quando o usuário fechar o navegador e abrir, ele pede a autenticação novamente. Caso o parâmetro seja "true", sempre que o usuário entrar no navegador e digitar a página, ele já vai entrar direto sem autenticação. Isso é um risco, pois pessoas mal-intencionadas consegue descriptografar o cookie e consegue pegar o usuário gravado.
                               */
                                FormsAuthentication.SetAuthCookie(login.email, false);

                                /* Verificação da string do site, isso por causa da segurança na hora do retorno. Caso o parâmetro returnURL seja maior que 1, significa que existe uma string. Após isso, ele verifica se inicia com uma barra, que é o padrão. Caso retorne duas barras é errado e ele não valida, e por último ele verifica.
                                 */
                                if (Url.IsLocalUrl(returnUrl)
                                    && returnUrl.Length > 1
                                    && returnUrl.StartsWith("/")
                                    && !returnUrl.StartsWith("//")
                                    && returnUrl.StartsWith("/\\"))
                                {
                                    return Redirect(returnUrl);
                                }

                                // Cria uma sessão para armazenar nome do usuário
                                Session["Nome"] = login.nome;

                                // Cria uma sessão para armazenar sobrenome do usuário
                                Session["Sobrenome"] = login.sobrenome;

                                // Redireciona para a tela incial na controller Home
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                // Caso senha inválida
                                ModelState.AddModelError("", "Senha informada é inválida!");
                                return View(new Acesso());
                            }
                        }
                        else
                        {
                            // Caso usuário não esteja mais ativo
                            ModelState.AddModelError("", "Usuário sem acesso ao sistema!");
                            return View(new Acesso());
                        }
                    }
                    else
                    {
                        // Caso o usuário não exista
                        ModelState.AddModelError("", "E-mail informado é inválido!");
                        return View(new Acesso());
                    }
                }
            }

            // Caso algum campo não esteja em ordem, ele retorna para a tela de Login com a respectiva mensagem de erro
            return View(acesso);
        }
    }
}