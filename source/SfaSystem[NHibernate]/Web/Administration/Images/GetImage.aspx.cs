using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;
using System.IO;

public partial class Administration_Images_GetImage : System.Web.UI.Page
{
    private byte[] arrNoImage;

    protected void Page_Load(object sender, EventArgs e)
    {
        ProcessRequest();
    }

    protected void ProcessRequest()
    {
        try
        {
            Guid id = new Guid(Context.Request.Params["id"]);
            //int type = int.Parse(Context.Request.Params["type"]);
            //string name = Context.Request.Params["name"];
            string preview = Context.Request.Params["preview"];
            //FileRepository file = FileRepositoryBLL.GetFileByName(id, (TargetType)type, name);
            SFASystem.Domain.Image file = BasicService<SFASystem.Domain.Image, Guid>.GetByID(id);//, (TargetType)type, name);
            if (preview == "1")
            {
            //    if (file != null)
            //    {
            //        Context.Response.ContentType = "image/jpeg";
            //        Context.Response.BinaryWrite(file.previewFile);
            //    }
            }
            else
            {
                if (file != null)
                {
                    Context.Response.ContentType = "image/jpeg";
                    Context.Response.BinaryWrite(file.ImageFile);
                }
                else
                {
                    if (arrNoImage == null)
                    {
                        FileStream stream = File.Open(Context.Server.MapPath("~/images/nophoto.gif"), FileMode.Open, FileAccess.Read, FileShare.Read);
                        Context.Response.ContentType = "image/gif";
                        arrNoImage = new byte[stream.Length];
                        stream.Read(arrNoImage, 0, arrNoImage.Length);
                        stream.Close();
                    }
                    Context.Response.BinaryWrite(arrNoImage);
                }
            }
        }
        catch
        {
            Context.Response.Clear();
            Context.Response.End();
        }
    }
}
