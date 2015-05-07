using Rainbow.Web.Storage;
using StandAloneWidget.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StandAloneWidget.Controllers
{
    public class UploadedFileController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /UploadedFile/List
        [Authorize]
        public ActionResult List(Guid? reference)
        {
            if (!reference.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var model = new UploadFileModel() { Reference = reference.Value };

            model.Files = UploadedFile.GetFiles(reference.Value);

            return View(model);
        }

        //
        // GET: /UploadedFile/Get
        [Authorize]
        public ActionResult Get(Guid? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var file = UploadedFile.Load(id.Value);

            if (file == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return File(file.Data, file.ContentType);
        }

        //
        // GET: /UploadedFile/Delete
        [Authorize]
        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var file = UploadedFile.Load(id.Value);

            file.Delete();

            file.AcceptChanges();

            return RedirectToAction("List", new { reference = file.ParentID });
        }

        //
        // GET: /UploadedFile/Upload
        [Authorize]
        public ActionResult Upload()
        {
            return View(new UploadFileModel() { Reference = Guid.NewGuid() });
        }

        //
        // POST: /UploadedFile/Get
        [Authorize]
        [HttpPost]
        public ActionResult Get(Guid? reference, HttpPostedFileBase file)
        {
            if (!reference.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var uploadedFile = new UploadedFile();

            uploadedFile.CreatedBy = User.Identity.Name;
            uploadedFile.FileName = file.FileName;
            uploadedFile.InputStream = file.InputStream;
            uploadedFile.ContentLength = file.ContentLength;
            uploadedFile.ContentType = file.ContentType;
            uploadedFile.ParentID = reference;

            uploadedFile.AcceptChanges();

            return RedirectToAction("List", new { reference = reference });
        }

        [AllowAnonymous]
        public FileContentResult GetImage(Guid ID)
        {
            var file = UploadedFile.Load(ID);

            return File(file.Data, file.ContentType);
        }

    }
}
