using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using VendaDeCarros.Media;
using VendaDeCarros.Droid;
using Xamarin.Forms;
using Android.Content;
using Android.Provider;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace VendaDeCarros.Droid
{
    [Activity(Label = "VendaDeCarros", 
              Icon = "@drawable/icon",
              Theme = "@style/MainTheme",
              MainLauncher = true,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICamera
    {
        static Java.IO.File arquivoImagem;

        public void TirarFoto()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            arquivoImagem = PegarArquivoImagem();


            /*Colocando dados no intent, nesse caso, um Output, que diz ao Android que a intenção tem dados extras
            e que esses dados são do tipo output (loca de saida), onde vai ser guardado o resultado final da captura da foto
            O segundo parametro é o endereço do local do arquivo, que é o valor propriamente dito
             */
            intent.PutExtra(MediaStore.ExtraOutput,
                Android.Net.Uri.FromFile(arquivoImagem));

            var activity = Forms.Context as Activity;
            activity.StartActivityForResult(intent, 0);
        }

        private static Java.IO.File PegarArquivoImagem()
        {
            /*Aqui se define o diretorio onde ficará o arquivo de imagem*/
            Java.IO.File diretorio = new Java.IO.File
                (
                    Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures),
                    "Imagens"
                );

            /*Aqui se verifica se o direrotio não existir, então se cria o diretorio do de arquivo de imagem*/
            if (!diretorio.Exists())
                diretorio.Mkdirs();


            /*Aqui se cria o arquivo de imagem*/
            arquivoImagem = new Java.IO.File(diretorio, "MinhaFoto.jpg");

            return arquivoImagem; 
        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            byte[] bytes;

            if (resultCode == Result.Ok)
            {
                using (var stream = new Java.IO.FileInputStream(arquivoImagem))
                {
                    bytes = new byte[arquivoImagem.Length()];
                    stream.Read(bytes);
                }
                    MessagingCenter.Send<byte[]>(bytes, "FotoTirada");
            }
        }
    }
}

