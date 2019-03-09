using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhoneBook.Data;
using PhoneBook.Interfaces;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactRepository contactRepository;
        private bool IsDBSeeded = false;

        public ContactController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        //seed some initial data
        [HttpGet("seeddb")]
        public IActionResult SeedDB()
        {
            if (!IsDBSeeded)
            {
                Contact[] contacts = {
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Joni Barrett",
                        Gender = "female",
                        Email =  "jonibarrett@micronaut.com",
                        Phone = "+1 (834) 548-3368"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Nolan Keith",
                        Gender = "male",
                        Email =  "nolankeith@micronaut.com",
                        Phone = "+1 (883) 404-3957"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Peck Richardson",
                        Gender = "male",
                        Email =  "peckrichardson@micronaut.com",
                        Phone = "+1 (970) 452-2870"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Horton Lopez",
                        Gender = "male",
                        Email =  "hortonlopez@micronaut.com",
                        Phone = "+1 (948) 468-2240"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Watson Everett",
                        Gender = "male",
                        Email =  "watsoneverett@micronaut.com",
                        Phone = "+1 (968) 579-3723"
                    },
                        new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Rachelle Mcintosh",
                        Gender = "female",
                        Email =  "rachellemcintosh@micronaut.com",
                        Phone = "+1 (858) 461-2591" },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Gale Solomon",
                        Gender = "female",
                        Email =  "galesolomon@micronaut.com",
                        Phone = "+1 (868) 541-3779"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Kimberley Beard",
                        Gender = "female",
                        Email =  "kimberleybeard@micronaut.com",
                        Phone = "+1 (851) 401-3347"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Reyes Crosby",
                        Gender = "male",
                        Email =  "reyescrosby@micronaut.com",
                        Phone = "+1 (996) 440-2162"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Adeline Horne",
                        Gender = "female",
                        Email =  "adelinehorne@micronaut.com",
                        Phone = "+1 (858) 407-2200"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Lewis Ray",
                        Gender = "male",
                        Email =  "lewisray@micronaut.com",
                        Phone = "+1 (858) 509-2205"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Franklin Stein",
                        Gender = "male",
                        Email =  "franklinstein@micronaut.com",
                        Phone = "+1 (869) 400-3273"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Randolph Barr",
                        Gender = "male",
                        Email =  "randolphbarr@micronaut.com",
                        Phone = "+1 (945) 437-2394"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Lorraine Mcfadden",
                        Gender = "female",
                        Email =  "lorrainemcfadden@micronaut.com",
                        Phone = "+1 (818) 487-3010"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Patrick Atkinson",
                        Gender = "male",
                        Email =  "patrickatkinson@micronaut.com",
                        Phone = "+1 (845) 525-3552"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Laura Hunter",
                        Gender = "female",
                        Email =  "laurahunter@micronaut.com",
                        Phone = "+1 (972) 528-3458"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Meadows Farrell",
                        Gender = "male",
                        Email =  "meadowsfarrell@micronaut.com",
                        Phone = "+1 (903) 466-2378"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Fields Craig",
                        Gender = "male",
                        Email =  "fieldscraig@micronaut.com",
                        Phone = "+1 (845) 536-3674"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Schmidt Acosta",
                        Gender = "male",
                        Email =  "schmidtacosta@micronaut.com",
                        Phone = "+1 (993) 424-2627"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Kerry Clark",
                        Gender = "female",
                        Email = "kerryclark@micronaut.com",
                        Phone = "+1 (844) 530-2208"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Sheppard Schneider",
                        Gender = "male",
                        Email = "sheppardschneider@micronaut.com",
                        Phone = "+1 (983) 408-2985"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Riley Singleton",
                        Gender = "male",
                        Email = "rileysingleton@micronaut.com",
                        Phone = "+1 (892) 521-2727"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Dillard Bowen",
                        Gender = "male",
                        Email = "dillardbowen@micronaut.com",
                        Phone = "+1 (854) 430-2072"
                    },
                    new Contact {
                        Id = Guid.NewGuid(),
                        Name = "Lott Knowles",
                        Gender = "male",
                        Email = "lottknowles@micronaut.com",
                        Phone = "+1 (863) 529-2532"
                    }
            };

                for (int i = 0; i < contacts.Length; i++)
                {
                    contactRepository.Insert(contacts[i]);
                }
                contactRepository.SaveAsync();
                IsDBSeeded = true;
            }

            var content = "<html><body><h3>InMemory database seeded!</h3><p>View test data <a href=\"https://localhost:44389/api/contact\">https://localhost:44389/api/contact</a></p></body></html>";

            return new ContentResult()
            {
                Content = content,
                ContentType = "text/html",
            };
        }

        [HttpGet]
        public object Get(int pageNumber = 1, int pageSize = 10, string searchInput = "")
        {
            try
            {
                var contacts = contactRepository.Get();

                if (!string.IsNullOrWhiteSpace(searchInput))
                {
                    contacts = contacts.Where(c => c.Name.StartsWith(searchInput) ||
                        c.Phone.ToString().StartsWith(searchInput) ||
                        c.Gender.ToString().StartsWith(searchInput) ||
                        c.Email.ToString().StartsWith(searchInput));
                }

                return new
                {
                    data = contacts.OrderBy(c => c.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToArray(),
                    total = contacts.Count()
                };
            }
            catch(Exception e)
            {
                //some logging here...

                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Contact contact)
        {
            try
            {
                contact.Id = Guid.NewGuid();
                contactRepository.Insert(contact);
                await contactRepository.SaveAsync();

                return Created("Contact", new { id = contact.Id });
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody]Contact contact)
        {
            var _contact = await contactRepository.GetByIdAsync(contact.Id);

            if(_contact == null)
            {
                return NotFound();
            }

            _contact.Email = contact.Email;
            _contact.Gender = contact.Gender;
            _contact.Name = contact.Name;
            _contact.Phone = contact.Phone;

            try
            {
                contactRepository.Update(_contact);
                await contactRepository.SaveAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var _contact = await contactRepository.GetByIdAsync(id);

            if (_contact == null)
            {
                return NotFound();
            }

            try
            {
                contactRepository.Delete(_contact);
                await contactRepository.SaveAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
