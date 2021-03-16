
  
  const doUpload = (url, options) => {
      const promiseCallback = (resolve, reject) => {
          fetch(url, options)
          .then(response => response.json())
          .then(resolve)
          .catch(reject)
      }
      return new Promise(promiseCallback);
  }
  
  
  const uploadImage = (e) => {
       e.preventDefault();

       const file = document.getElementById('file-img');

       const data = new FormData();
       data.append('image', file.files[0]);


       doUpload('https://localhost:44371/api/ImageUpload', {
           method: 'POST',
           body: data,
           headers: {
            'Content-Type': 'application/json'
           }
         
       })
       .then(console.log)
       .catch(console.error)
   }
// teste commitiii

   const form = document.getElementById('upload-form');
   console.log(form)
   form.addEventListener('submit', uploadImage)