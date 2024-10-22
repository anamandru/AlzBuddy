import requests

url = "http://127.0.0.1:12345/get_data"
response = requests.get(url)

print("Response Code:", response.status_code)
print("Response Data:", response.json())  # Assuming the response is in JSON format
