using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using System.Linq;
using System.Windows;
using Dreambuild.AutoCAD;
using System;
using System.Diagnostics.Eventing.Reader;
[assembly: CommandClass(typeof(AutoCADCommands.EVS.CopyMtext))]
namespace AutoCADCommands.EVS
{
    public class CopyMtext
    {
        [CommandMethod("COPYMTEXTEVS", CommandFlags.UsePickSet)]
        public static void COPYMTEXTEVS()
        {

            //var ids = Interaction.GetSelection("\nSelect MText", "MTEXT, TEXT");
            var ids = Interaction.GetSelection("\nSelect MText or TEXT\n", "*TEXT,MTEXT");
            using (Entity ent = (Entity)ids.FirstOrDefault().Open(OpenMode.ForRead))

            {
                Interaction.Write($"ТИП ВЫБРАННОГО ПРИМИТИВА -  {ent.GetType()}");

                //if (ent == null)

                //{
                //    return;
                //}

                if (ent.GetType() == typeof(MText))
                {
                    var mts = ids.QOpenForRead<MText>().FirstOrDefault(mt =>
                    {

                        Clipboard.Clear();
                        Clipboard.SetText(mt.Text);
                        Interaction.Write($"В буфере: {mt.Text}");
                        return true;
                    });
                }
                if (ent.GetType() == typeof(DBText))
                {
                    var dts = ids.QOpenForRead<DBText>().FirstOrDefault(dt =>
                          {

                              Clipboard.Clear();
                              Clipboard.SetText(dt.TextString);
                              Interaction.Write($"В буфере: {dt.TextString}");
                              return true;

                               //var mt = NoDraw.MText(dt.TextString, dt.Height, dt.Position, dt.Rotation, false);
                               //mt.Layer = dt.Layer;
                               //return mt;
                           });
                }

            }


        }


    }
}








