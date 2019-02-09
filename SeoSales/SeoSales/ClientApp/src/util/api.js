export function post(uri, body, options) {

  const fetchOptions = {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Accept': 'application/json',
    },
    body: JSON.stringify(body),
    ...options
  }

  return new Promise((resolve, reject) => {
    fetch(uri, fetchOptions)
      .then(response => {
        if (response.status === 200) {
          return resolve(response.json());
        } else {
          return reject({status: response.status, body: response.json()});
        }
      });
  });
}