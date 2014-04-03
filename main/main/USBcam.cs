using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

//Video Libraries. These are part of the AForge Framework stored under C:/Programs(x86)/AForge.NET/framework/release/
// and have been added through Project --> Add Reference
using AForge.Video;
using AForge.Video.DirectShow;

namespace USBcam
{
    class USBcamclass
    {
        private FilterInfoCollection available_cameras; //This is used to fetch a list of all the available cameras.
        public VideoCaptureDevice camera_stream; //This is the actual camera feed that will give us the image.
        public Bitmap camera_image { get; set; }

        public USBcamclass()
        {
            available_cameras = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                camera_stream = new VideoCaptureDevice(available_cameras[0].MonikerString); //Currently the System will use the first camera found.
                camera_stream.Start();
        }

        public void fetch_new_image(NewFrameEventArgs camera_event_data)
        {
            camera_image = (Bitmap)camera_event_data.Frame.Clone();
            camera_image.RotateFlip(RotateFlipType.Rotate180FlipY);
        }
    }
}
